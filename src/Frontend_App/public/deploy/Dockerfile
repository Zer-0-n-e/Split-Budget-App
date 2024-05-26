FROM nginx:stable-alpine

# Create a non-root user
ARG USER_NAME=budget
ARG USER_ID=1001
ARG GROUP_ID=1001

RUN addgroup -g $GROUP_ID $USER_NAME \
    && adduser -u $USER_ID -G $USER_NAME -s /bin/bash -D $USER_NAME

RUN apk add --no-cache openssl && \
    apk add --no-cache bash && \
    apk update && \
    apk add --update ncurses-libs && \
    apk add --update curl && \
    apk add --update openssl && \
    apk upgrade && \
    apk add nodejs


# Switch to the non-root user
USER $USER_NAME

# Start Nginx server and execute shell scripts
CMD ["/bin/bash", "-c","\nginx -g \"daemon off;\""]
